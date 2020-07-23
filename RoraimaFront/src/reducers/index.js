
import { combineReducers } from 'redux';
import { routerReducer } from 'react-router-redux';

import resume from './resume';
import search from './search';


export default combineReducers({
    routing: routerReducer,
    resume, 
    search
});