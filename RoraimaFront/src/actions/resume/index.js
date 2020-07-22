const saveResumeApi = require('api/resume/').saveResume
export const saveResume = (params) => async (dispatch) => {
    dispatch({ type: 'SAVE_RESUME_START' });
    try {
        const res = await saveResumeApi(params);
        dispatch({
            type: 'SAVE_RESUME_SUCCESS',
            payload: res
        });
    } catch (err) {
        dispatch({
            type: 'SAVE_RESUME_FAILURE',
            payload: err
        });
        return err;
    }
};