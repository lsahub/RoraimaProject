import React from 'react';
import queryString from 'query-string';
import SearchItem from 'components/searchItem';
import { useSelector,  connect } from 'react-redux'

 

const Fragment = React.Fragment;

const Search = (props) => {
  let params = queryString.parse(props.location.search)
  const searchList = useSelector(state => state.search.searchResult.list);

  return (
    <Fragment>
      {
        params.text.length > 0 &&
        <div style={{ marginBottom: '20px'}}>Поиск «{`${params.text}»`} {searchList.length}</div>
      }      
      <div>
        {
          searchList.map((item, index)=>(
            <SearchItem 
              title={item.title}
              text={item.text}
            />
          ))
        }
        {
          searchList.length == 0 && params.text.length > 0 &&
          <div style={{ padding: '20px 0px 20px 0px' }}>Ничего не найдено</div>
        }
      </div>
    </Fragment>    
  );
};



export default Search;