import { useEffect, useRef, useState } from 'react';
import * as THREE from 'three';

import './App.css';

function Cube() {
  const refContainer = useRef();
  const [renderer, setRenderer] = useState();

  useEffect(() => {
    const { current: container } = refContainer;
    if (container && !renderer) {
      const containerWidth = container.clientWidth;
      const containerHeight = container.clientHeight;
      const scene = new THREE.Scene();
      const camera = new THREE.PerspectiveCamera(
        75,
        window.innerWidth / window.innerHeight,
        0.1,
        1000
      );
      const render = new THREE.WebGLRenderer();
      render.setSize(containerWidth, containerHeight);
      setRenderer(render);

      container.appendChild(render.domElement);
    }
  }, []);

  return (
    <div
      className="App-cube"
      ref={refContainer}
    >
    </div>
  );
}

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <p>
          QTicTacToe.
        </p>
        <a
          className="App-link"
          href="https://github.com/WiL-dev/QTicTacToe"
          target="_blank"
          rel="noopener noreferrer"
        >
          Github repo
        </a>
      <Cube />
      </header>
    </div>
  );
}

export default App;
