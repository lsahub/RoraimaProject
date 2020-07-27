const initialState = {
    //список возможной видимости резюме
    searchResult: {
        totalCount: 0,
        list: []
    },
};

export default (state = initialState, { type, payload }) => {
    let res = null;
    switch (type) {

        //#region FETCH_SEARCH_LIST_SUCCESS
        case 'FETCH_SEARCH_LIST_SUCCESS':
            {
                res = Object.assign({}, state);
                res.searchResult.totalCount = payload.payload.totalCount;
                res.searchResult.list = payload.payload.searchResult;
                res.ex = null;
                return res;
            }
        case 'FETCH_SEARCH_LIST_FAILURE':
            {
                res = Object.assign({}, state);
                res.searchResult.totalCount = 0;
                res.searchResult.list = [];
                res.ex = payload;
                return res;
            }
        //#endregion 
 
        default:
            return state;
    }
}