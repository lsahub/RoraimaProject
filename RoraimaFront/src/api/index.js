export const getApiUrl = (_url) => {
    let frontApi = "http://localhost:65338/api";
    let url = `${frontApi}${_url}`;

    return {
        url: url
    }
} 