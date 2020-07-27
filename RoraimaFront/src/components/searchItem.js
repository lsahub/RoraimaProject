import React from 'react';


const Fragment = React.Fragment;

const Search = (props) => {
  var lastJob = "";
  if(props.resume && props.resume.resumeExperienceList && props.resume.resumeExperienceList.length > 0)
    lastJob = props.resume.resumeExperienceList[props.resume.resumeExperienceList.length - 1];

  return (
    <Fragment>
      <div className='search-item'>
        <h4>{`${props.resume.resumeTitle}`}</h4>
        <h6>{`${props.resume.lastName} ${props.resume.firstName} ${props.resume.middleName}`}</h6>
        <div>
          <small class="text-muted">Последнее место работы</small>
          <div>            
            {`${lastJob && lastJob.position}`}
          </div>
        </div>
      </div>
    </Fragment>    
  );
};

export default Search; 