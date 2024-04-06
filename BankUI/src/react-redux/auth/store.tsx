import { createStore } from 'redux';
import { combineReducers } from 'redux';
import authReducer from './reducers';

const rootReducer = combineReducers({
  auth: authReducer,
});

const store = createStore(rootReducer);

export default store;
