const fetchResumeVisibilityListApi = require('api/resumeVisibility/').fetchResumeVisibilityList;
export const fetchResumeVisibilityList = (params) => async (dispatch) => {
    dispatch({ type: 'FETCH_RESUME_VISIBILITY_LIST_START' });
    try {
        const account = await fetchResumeVisibilityListApi(params);
        dispatch({
            type: 'FETCH_RESUME_VISIBILITY_LIST_SUCCESS',
            payload: account
        });
    } catch (err) {
        dispatch({
            type: 'FETCH_RESUME_VISIBILITY_LIST_FAILURE',
            payload: err
        });
    }
};