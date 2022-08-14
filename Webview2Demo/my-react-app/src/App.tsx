import reactSvg from "./assets/react.svg";
function App() {
  const handleClick = () => {
    fetch("http://localhost:5000/ShowMessageBox?msg=我是 React")
      .then((r) => r.text())
      .then((r) => {
        console.log("返回值:", r);
      });
  };

  return (
    <div
      style={{
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        justifyItems: "center",
      }}
    >
      <h1>.Net + WebView2 + React</h1>
      <img src={reactSvg} width={100} height={100} />
      <button style={{ width: "100px" }} onClick={handleClick}>
        Click
      </button>
    </div>
  );
}

export default App;
