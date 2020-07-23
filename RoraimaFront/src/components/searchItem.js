import React from 'react';


const Fragment = React.Fragment;

const Search = (props) => {

  return (
    <Fragment>
      <div 
        className='search-item'
      >
        <h3>{props.title}</h3>
        <div>{props.text}</div>
      </div>
    </Fragment>    
  );
};

export default Search; 