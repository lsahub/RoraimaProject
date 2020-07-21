
import { combineReducers } from 'redux';
import { routerReducer } from 'react-router-redux';

import resume from './resume';


export default combineReducers({
    routing: routerReducer,
    resume, 
});