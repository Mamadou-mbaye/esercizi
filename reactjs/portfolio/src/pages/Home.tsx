import { startTransition, useEffect, useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faGithub, faLinkedin } from "@fortawesome/free-brands-svg-icons";
import { lazy } from "react";
const About = lazy(() => import("../components/About"));
const Portfolio = lazy(() => import("../components/Portfolio"));
const Skills = lazy(() => import("../components/Skills"));
const Tecnologies = lazy(() => import("../components/Tecnologies"));
interface HeaderProps {
  homeRef: React.RefObject<HTMLDivElement>;
  aboutRef: React.RefObject<HTMLDivElement>;
  portfolioRef: React.RefObject<HTMLDivElement>;
  contactRef: React.RefObject<HTMLDivElement>;
}
const Home: React.FC<HeaderProps> = ({
  homeRef,
  aboutRef,
  portfolioRef,
  contactRef,
}) => {
  const [bodyWidth, setBodyWidth] = useState(window.innerWidth);
  const [infoContent, setInfoContent] = useState(<About />);

  const handleAboutClick = () => {
    startTransition(() => {
      setInfoContent(<About />);
    });
  };
  const handleSkillsClick = () => {
    startTransition(() => {
      setInfoContent(<Skills />);
    });
  };
  const handlePortfolioClick = () => {
    startTransition(() => {
      setInfoContent(<Portfolio />);
    });
  };
  const handleTecnologiesClick = () => {
    startTransition(() => {
      setInfoContent(<Tecnologies />);
    });
  };
  useEffect(() => {
    const handleResize = () => {
      setBodyWidth(window.innerWidth);
    };
    window.addEventListener("resize", handleResize);
    const handleDisplayTitles = () => {
      const titles: HTMLElement = document.getElementById(
        "titles"
      ) as HTMLElement;

      if (bodyWidth < 500) {
        titles.classList.add("flex-col");
      } else {
        titles.classList.remove("flex-col");
      }
    };
    handleDisplayTitles();
  }, [bodyWidth]);
  return (
    <main
      id="main"
      className="w-4/5 min-w-80 min-h-screen flex flex-col gap-5 items-center justify-self-center"
    >
      <section
        id="section"
        className="w-full flex flex-col items-center"
        ref={homeRef}
      >
        <div className="h-48 flex flex-col justify-center items-center gap-4">
          <h3 className="text-4xl">Web Developer</h3>
          <p className="text-xl text-center text-balance min-w-80  w-96 p-0 m-0 ">
            Hi, I'm <span className="text-sky-400 text-2xl">Mamadou</span>, a
            passionate full-stack web developer with skills in both front-end
            and back-end technologies.
          </p>
        </div>
        <div className="min-h-52 flex flex-col justify-center items-center gap-4">
          <h3 className="text-4xl" translate="no">
            Tech Stack
          </h3>
          <div className="flex flex-row gap-4 flex-wrap justify-center items-center text-xl">
            <p>
              <span className="mx-2" translate="no">
                HTML
              </span>
              <i className="fa-brands fa-html5"></i>
            </p>
            <p>
              <span className="mx-2" translate="no">
                CSS
              </span>
              <i className="fa-brands fa-css3-alt"></i>
            </p>
            <p>
              <span className="mx-2" translate="no">
                JAVASCRIPT
              </span>
              <i className="fa-brands fa-js"></i>
            </p>
            <p>
              <span className="mx-2" translate="no">
                REACT
              </span>
              <i className="fa-brands fa-react"></i>
            </p>
            <p>
              <span className="mx-2" translate="no">
                JAVA
              </span>
              <i className="fa-brands fa-java"></i>
            </p>
          </div>
        </div>
        <div
          id="info"
          className="grid gap-4 place-items-center mb-4 divide-y-2 divide-solid max-w-3xl"
        >
          <div
            id="titles"
            className="flex justify-evenly w-full flex-wrap gap-2"
          >
            <h3
              id="about"
              className="text-xl cursor-pointer text-black bg-stone-200 rounded-lg min-w-24 text-center hover:bg-stone-400"
              onClick={handleAboutClick}
              ref={aboutRef}
            >
              About Me
            </h3>
            <h3
              id="portfolio"
              className="text-xl cursor-pointer text-black bg-stone-200 rounded-lg min-w-24 text-center hover:bg-stone-400"
              onClick={handlePortfolioClick}
              ref={portfolioRef}
            >
              Portfolio
            </h3>
            <h3
              id="skills"
              className="text-xl cursor-pointer text-black bg-stone-200 rounded-lg min-w-20 text-center hover:bg-stone-400"
              onClick={handleSkillsClick}
            >
              Skills
            </h3>
            <h3
              id="tecnologies"
              className="text-xl cursor-pointer text-black bg-stone-200 rounded-lg min-w-28 text-center hover:bg-stone-400"
              onClick={handleTecnologiesClick}
            >
              Tecnologies
            </h3>
          </div>
          <div
            id="info-content"
            className="text-slate-300 text-balance text-center grid place-items-center"
          >
            {infoContent}
          </div>
        </div>
      </section>
      <aside
        id="aside"
        className="w-full flex justify-center items-center flex-col gap-5 p-0 m-0"
      >
        <div id="img-container" className="w-72 h-80 rounded-3xl"></div>
        <div id="social-links" className="text-5xl flex gap-4" ref={contactRef}>
          <a
            href="https://github.com/Mamadou-mbaye"
            target="_blank"
            rel="noreferrer"
          >
            <FontAwesomeIcon
              className="text-slate-300 hover:text-slate-400"
              icon={faGithub}
            />
          </a>
          <a
            href="http://linkedin.com/in/mamadou-mbae-045modu"
            target="_blank"
            rel="noreferrer"
          >
            <FontAwesomeIcon
              className="text-slate-300 hover:text-slate-400"
              icon={faLinkedin}
            />
          </a>
        </div>
      </aside>
    </main>
  );
};
export default Home;
