//#region initialState
const initialState = {
    resumeVisibility: {
        list: []
    }
};
//#endregion initialState

export default (state = initialState, { type, payload }) => {
    let res = null;
    switch (type) {

        //#region FETCH_RESUME_VISIBILITY_LIST_SUCCESS
        case 'FETCH_RESUME_VISIBILITY_LIST_SUCCESS':
            {
                res = Object.assign({}, state);
                res.resumeVisibility.list = payload.payload;
                return res;
            }
        case 'FETCH_RESUME_VISIBILITY_LIST_FAILURE':
            {
                res = Object.assign({}, state);
                res.resumeVisibility.list = [];
                res.resumeVisibility.ex = payload.payload;
                return res;
            }
        //#endregion
 
        default:
            return state;
    }
}