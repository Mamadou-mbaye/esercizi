const Tecnologies = () => {
  return (
    <>
      <ul className=" list-none grid gap-4 mt-4">
        <li className="max-w-2xl w-auto">
          <strong translate="no">Nodejs</strong>
          <br /> Used for building server-side applications. I have built
          several back-end services with Node.js and Express.js.
        </li>
        <hr className="w-3/4 mx-auto " />
        <li className="max-w-2xl w-auto">
          <strong translate="no">Expressjs</strong>
          <br /> A web application framework for Node.js that I use for creating
          APIs and handling server-side logic.
        </li>
        <hr className="w-3/4 mx-auto " />
        <li className="max-w-2xl w-auto">
          <strong translate="no">MySQL</strong>
          <br /> My preferred database for handling relational data, which I
          have used in conjunction with Sequelize.
        </li>
        <hr className="w-3/4 mx-auto " />
        <li className="max-w-2xl w-auto">
          <strong translate="no">Sequelize</strong>
          <br /> An ORM for Node.js that I use for managing database
          interactions in my projects.
        </li><hr className="w-3/4 mx-auto " />
        <li className="max-w-2xl w-auto">
          <strong translate="no">TypeORM</strong>
          <br />
          An ORM for Node.js (with Typescript) that I used for managing database interactions in a
          project during my internship.
        </li>

        <hr className="w-3/4 mx-auto " />
        <li className="max-w-2xl w-auto">
          <strong translate="no">Git & GitHub</strong>
          <br /> Essential tools for version control and collaboration. I use
          Git for version control and GitHub for hosting my repositories.
        </li>
        <hr className="w-3/4 mx-auto " />
        <li className="max-w-2xl w-auto">
          <strong translate="no">RESTful APIs</strong>
          <br /> I design and implement RESTful APIs to facilitate communication
          between the front-end and back-end of my applications.
        </li>
      </ul>
    </>
  );
};
export default Tecnologies;
