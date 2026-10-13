const express = require("express");
const jwt = require("jsonwebtoken");
const cookieParser = require('cookie-parser');

const app = express();
const port = 3000;

const ACCESS_SECRET = "access_secret_key";
const REFRESH_SECRET = "refresh_secret_key";

const users = [{ id: 1, username: "mamadou", password: "1234" }];

const refreshTokens = [];

app.use(express.json());
app.use(cookieParser());

app.post("/login", (req, res) => {
  const { username, password } = req.body;
  const user = users.find(
    (u) => u.username === username && u.password === password,
  );

  if (!user) {
    return res.status(401).json({ message: "Credenziali non valide" });
  }

  const accessToken = jwt.sign({ userId: user.id }, ACCESS_SECRET, {
    expiresIn: "15m",
  });
  const refreshToken = jwt.sign({ userId: user.id }, REFRESH_SECRET, {
    expiresIn: "7d",
  });

  refreshTokens.push(refreshToken);



  // Quello che facciamo nella demo — nel body, JavaScript può leggerlo
// res.json({ accessToken, refreshToken });

// In produzione — nel cookie, JavaScript NON può leggerlo (httpOnly)
res.cookie('refreshToken', refreshToken, { httpOnly: true, secure: true });
res.json({ accessToken }); // solo l'access token nel body

});

const authenticateToken = (req, res, next) => {
    const authHeader = req.headers['authorization'];
    const token = authHeader && authHeader.split(' ')[1];

    if (!token) {
        return res.status(401).json({ message: 'Token mancante' });
    }

    jwt.verify(token, ACCESS_SECRET, (err, user) => {
        if (err) {
            return res.status(403).json({ message: 'Token non valido o scaduto' });
        }
        req.user = user;
        next();
    });
};

app.get('/protected', authenticateToken, (req, res) => {
    res.json({ message: `Ciao ${req.user.username}, sei autenticato!` });
});

app.post('/refresh', (req, res) => {
    // const { refreshToken } = req.body;
const refreshToken = req.cookies.refreshToken;

    if (!refreshToken) {
        return res.status(401).json({ message: 'Refresh token mancante' });
    }

    if (!refreshTokens.includes(refreshToken)) {
        return res.status(403).json({ message: 'Refresh token non valido' });
    }

    jwt.verify(refreshToken, REFRESH_SECRET, (err, user) => {
        if (err) {
            return res.status(403).json({ message: 'Refresh token scaduto' });
        }

        const newAccessToken = jwt.sign(
            { id: user.id, username: user.username },
            ACCESS_SECRET,
            { expiresIn: '15m' }
        );

        res.json({ accessToken: newAccessToken });
    });
});
app.post('/logout', (req, res) => {
    // const { refreshToken } = req.body;
const refreshToken = req.cookies.refreshToken;

    const index = refreshTokens.indexOf(refreshToken);
    if (index === -1) {
        return res.status(403).json({ message: 'Refresh token non valido' });
    }

    refreshTokens.splice(index, 1);

    res.json({ message: 'Logout effettuato' });
});

app.get("/", (req, res) => {
  res.send("Hello World!");
});

app.listen(port, () => {
  console.log(`Server is running on http://localhost:${port}`);
});
