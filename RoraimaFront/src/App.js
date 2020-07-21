import React from 'react';
import Routes from 'routes';
import { BrowserRouter } from 'react-router-dom';
import TopBar from 'components/topBar';
import Footer from 'components/footer';

import 'bootstrap/dist/css/bootstrap.min.css';
import 'design/sass/main.scss'

function App() {
  return (
    <div className="container">
      <BrowserRouter>
        <TopBar />
        <Routes />
        <Footer />
      </BrowserRouter>
    </div>
  );
}

export default App;
