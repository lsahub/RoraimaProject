export const getApiUrl = (_url) => {
    let frontApi = "http://localhost:6533/api";
    let url = `${frontApi}${_url}`;

    return {
        url: url
    }
} 