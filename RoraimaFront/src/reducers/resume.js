const initialState = {
    //список возможной видимости резюме
    resumeVisibility: {
        list: []
    },
    //сохраненное резюме
    savedResume : {
        resume: {}
    }
};

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
                res.ex = payload;
                return res;
            }
        //#endregion
        //#region SAVE_RESUME_SUCCESS
        case 'SAVE_RESUME_SUCCESS':
            {
                res = Object.assign({}, state);
                res.savedResume.resume = payload.payload;
                return res;
            }
        case 'SAVE_RESUME_FAILURE':
            {
                res = Object.assign({}, state);
                res.savedResume.resume = {};
                res.ex = payload;
                return res;
            }
        //#endregion
 
        default:
            return state;
    }
}