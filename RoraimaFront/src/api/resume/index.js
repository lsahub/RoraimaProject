import request from 'superagent';
import { getApiUrl } from 'api';

export const saveResume = async (params) => {

    let settings = getApiUrl(`/resume`);
    const { body } = await request
        .post(settings.url)
        //.type('form')
        .send(params);
    return body;
};