import React from 'react';
import { fetchResumeVisibilityList } from 'actions/resumeVisibility'
import { useSelector,  connect } from 'react-redux'
import { useFetching } from 'hook';


const Fragment = React.Fragment;
const ResumeVisiibility = (props) => {

    useFetching(props.fetchResumeVisibilityList, null, null);
    const todo = useSelector(state => state.resume.resumeVisibility.list);

    const resumeVisiibilityList = useSelector(state => state.resume.resumeVisibility.list);
    return (
        <Fragment>
            {resumeVisiibilityList.map((row, index) => (
                <div key={`resumeVisiibilityList${row.resumeVisibilityId}`}  className="custom-control custom-radio">                        
                    <input 
                        onChange={()=>{props.onChange(row.resumeVisibilityId)}} 
                        type="radio" 
                        id={`customRadio${row.resumeVisibilityId}`} 
                        name="customRadio" 
                        className="custom-control-input" 
                        value={row.resumeVisibilityId} 
                        checked={row.resumeVisibilityId == props.value} 
                    />
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
