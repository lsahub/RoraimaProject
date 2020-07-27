import React, { useEffect } from 'react';
import queryString from 'query-string';
import SearchItem from 'components/searchItem';
import { useSelector,  connect } from 'react-redux'
import { declOfNum } from 'selectors'
import { withRouter } from 'react-router-dom';
import { fetchSearchList } from 'actions/search';

const Fragment = React.Fragment;

const Search = (props) => {
  let params = queryString.parse(props.location.search)
  const searchList = useSelector(state => state.search.searchResult.list);
  const totalCount = useSelector(state => state.search.searchResult.totalCount);

  useEffect( () => {
    props.fetchSearchList({
      text: params.text
    });
  }, [])

  return (
    <Fragment>
      {
        totalCount > 0 &&
        <div style={{ marginBottom: '20px'}}>Найдено {totalCount} { declOfNum(totalCount, ['вакансия', 'вакансии', 'вакансий'])} «{`${params.text}»`}</div>
      }      
      <div>
        {
          searchList.map((resume, index)=>(
            <SearchItem 
              resume={resume}
            />
          ))
        }
        {
          totalCount == 0 && params.text.length > 0 &&
          <div style={{ padding: '20px 0px 20px 0px' }}>Ничего не найдено</div>
        }
      </div>
    </Fragment>    
  );
};

const mapDispatch = {
  fetchSearchList
};

export default connect(null, mapDispatch)(withRouter(Search));