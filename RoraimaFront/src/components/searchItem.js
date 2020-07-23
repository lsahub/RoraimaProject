import React from 'react';


const Fragment = React.Fragment;

const Search = (props) => {

  return (
    <Fragment>
      <div 
        className='search-item'
      >
        <h4>{props.title}</h4>
        <div>{props.text}</div>
      </div>
    </Fragment>    
  );
};

export default Search; 