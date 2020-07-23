const fetchSearchListApi = require('api/search/').fetchSearchList;
export const fetchSearchList = (params) => async (dispatch) => {
    dispatch({ type: 'FETCH_SEARCH_LIST_START' });
    try {
        const account = await fetchSearchListApi(params);
        dispatch({
            type: 'FETCH_SEARCH_LIST_SUCCESS',
            payload: account
        });
    } catch (err) {
        dispatch({
            type: 'FETCH_SEARCH_LIST_FAILURE',
            payload: err
        });
    }
};