import { useEffect, useRef } from 'react';
import * as THREE from 'three';
import { OrbitControls } from "three/examples/jsm/controls/OrbitControls";

import './App.css';

function Cube() {
  const refContainer = useRef();
  const refRenderer = useRef();

  useEffect(() => {
    const { current: container } = refContainer;
    const { current: renderer } = refRenderer;

    if (container && !renderer) {
      const containerWidth = container.clientWidth;
      const containerHeight = container.clientHeight;
      const scene = new THREE.Scene();
      const camera = new THREE.PerspectiveCamera(
        75,
        containerWidth / containerHeight,
        0.1,
        1000
      );
      const render = new THREE.WebGLRenderer();
      render.setSize(containerWidth, containerHeight);
      refRenderer.current = render;

      container.appendChild(render.domElement);

      const geometry = new THREE.BoxGeometry(1, 1, 1);
      const material = new THREE.MeshBasicMaterial({ color: 0x00ff00 });
      const board = new THREE.Mesh(geometry, material);
      scene.add(board);

      camera.position.z = 1.7;
      const controls = new OrbitControls(camera, render.domElement);
      const target = new THREE.Vector3(0.1, 0.1, 0.1);
      controls.target = target;

      function animate() {
        requestAnimationFrame(animate);
        // board.rotation.x += 0.01;
        // board.rotation.y += 0.005;
        render.render(scene, camera);
      }
      animate();
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
