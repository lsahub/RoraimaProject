import request from 'superagent';
import { getApiUrl } from 'api';

export const fetchSearchList = async (params) => {
    let settings = getApiUrl(`/search?text=${params.text}`);
    const { body } = await request
        .get(settings.url)
    return body;
};