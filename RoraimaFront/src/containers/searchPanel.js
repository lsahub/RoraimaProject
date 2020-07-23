import React, { useState, useEffect } from 'react';
import { withRouter } from 'react-router-dom';
import { fetchSearchList } from 'actions/search';
import { connect } from 'react-redux'

const SearchPanel = (props) => {
  const [searchValue, setSearchValue] = useState("");
  const [searchText, setSearchText] = useState("");
  const [redirectToSearchPage, setRedirectToSearchPage] = useState(false);

  useEffect( () => {
    if(redirectToSearchPage)
    {
      props.fetchSearchList({
        text: searchValue
      });
    }

    if(redirectToSearchPage)
    {
      setRedirectToSearchPage(false);
      props.history.push(`/search?text=${searchText}`);
    }

  }, [redirectToSearchPage])

  return ( 
    <React.Fragment>
        <div className={`search-panel ${props.showSearch ? 'show' : ''}`}>
          <input 
            value={searchValue} 
            onChange={e => setSearchValue(e.target.value)} 
            className='form-control rounded-0'
            id="searchValue" 
            placeholder="Поиск" 
            maxLength="500" 
            required
            onKeyPress={event => {
              if (event.key === 'Enter') {
                setSearchText(searchValue);
                setRedirectToSearchPage(true);
              }
            }} 
          />
          <button 
            onClick={()=>{
              setSearchText(searchValue);
              setRedirectToSearchPage(true);
            }}
            type="button" 
            className="btn btn-primary rounded-0"
          >Найти</button>
        </div>
    </React.Fragment>

  );
};



const mapDispatch = {
  fetchSearchList
};


export default connect(null, mapDispatch)(withRouter(SearchPanel));