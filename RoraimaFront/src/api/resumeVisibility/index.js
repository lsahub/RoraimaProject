import request from 'superagent';
import { getApiUrl } from 'api';

export const fetchResumeVisibilityList = async (params) => {
    let settings = getApiUrl(`/resumeVisibility/list`);
    const { body } = await request
        .get(settings.url)
    return body;
};