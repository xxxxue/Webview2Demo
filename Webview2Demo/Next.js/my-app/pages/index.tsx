import type { NextPage } from "next";

const Home: NextPage = () => {
  let handleClick = () => {
    fetch("http://localhost:5000/api/my/show-message-box?msg=哈哈哈")
      .then((a) => a.json())
      .then((a) => {
        console.log(a);
      });
  };
  return (
    <>
      <h1>next.js app</h1>

      <button onClick={handleClick}>click</button>
      
    </>
  );
};

export default Home;
