import React, {useState, useEffect, useContext, useCallback} from 'react';
import { fetchResumeVisibilityList } from 'actions/resumeVisibility'
import { useSelector, useDispatch, connect } from 'react-redux'
import { useFetching } from 'hook';


const Fragment = React.Fragment;
const ResumeVisiibility = (props) => {

    useFetching(props.fetchResumeVisibilityList);
    const todo = useSelector(state => state.resume.resumeVisibility.list);

    const resumeVisiibilityList = useSelector(state => state.resume.resumeVisibility.list);
    debugger;
    return (
        <Fragment>
                    {resumeVisiibilityList.map((row, index) => (
                        <div className="custom-control custom-radio">                        
                            <input type="radio" id={`customRadio${row.resumeVisibilityId}`} name="customRadio" className="custom-control-input" value={row.resumeVisibilityId} />
                            <label className="custom-control-label" htmlFor={`customRadio${row.resumeVisibilityId}`}>{row.title}</label>
                        </div>
                    ))}
        </Fragment>
  );
};

const mapDispatch = {
    fetchResumeVisibilityList
};


export default connect(null, mapDispatch)(ResumeVisiibility);