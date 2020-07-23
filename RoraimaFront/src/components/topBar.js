import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { fetchSearchList } from 'actions/search';
import { connect } from 'react-redux'
import SearchPanel from 'containers/searchPanel'

const Topbar = (props) => {

  const [showSearch, setShowSearch] = useState(false);


  return ( 
    <React.Fragment>
      <header className="blog-header py-3 site-header">
        <div className="row flex-nowrap justify-content-between align-items-center top-bar">
          <div className="col-4 pt-1">
            <Link to="/" ><img className="img-responsive navbar-brand-logo" src='https://i.hh.ru/logos/svg/hh.ru__min_.svg' /></Link>

          </div>

          <div onClick={()=>{setShowSearch(!showSearch);}} className="col-8 d-flex justify-content-end align-items-center">
            <a               
              className="p-2 text-menu-link" 
              href="#"
            >
              <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round" className="mx-2"><circle cx="10.5" cy="10.5" r="7.5"></circle><line x1="21" y1="21" x2="15.8" y2="15.8"></line></svg>
              Поиск
            </a>
            <a 
              onClick={()=>{
                alert('Функция не реализована')
              }} 
              className="text-menu-link" 
              href="#">Sign up</a>
          </div>
        </div>
        <SearchPanel showSearch={showSearch} />
      </header> 
      
    </React.Fragment>

  );
};



const mapDispatch = {
  fetchSearchList
};


export default connect(null, mapDispatch)(Topbar);