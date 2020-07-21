import React from 'react';
import Routes from 'routes';
import { BrowserRouter } from 'react-router-dom';
import TopBar from 'components/topBar';
import Footer from 'components/footer';
import { createStore, applyMiddleware } from 'redux';
import { composeWithDevTools } from 'redux-devtools-extension';
import thunk from 'redux-thunk';
import { Provider } from 'react-redux';
import reducers from 'reducers';

import 'bootstrap/dist/css/bootstrap.min.css';
import 'design/sass/main.scss'

let store = createStore(reducers, composeWithDevTools(applyMiddleware(thunk)));

function App() {
  return (
    <Provider store={store}>
      <div className="container">
        <BrowserRouter>
          <TopBar />
          <Routes />
          <Footer />
        </BrowserRouter>
      </div>
    </Provider>
  );
}

export default App;
