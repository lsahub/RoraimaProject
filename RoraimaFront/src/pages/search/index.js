import React from 'react';
import queryString from 'query-string'
import SearchItem from 'components/searchItem'
const Fragment = React.Fragment;

const Search = (props) => {
  let params = queryString.parse(props.location.search)
  debugger;
  return (
    <Fragment>
      <div>Поиск «{`${params.text}»`}</div>
      <div 
        style={{border: '1px solid #cabebe', padding: '20px 15px 20px 35px', width: '100%'}}
      >
        <SearchItem title='Липовкин Сергей' text='Разработка высоконагруженных масштабируемых приложений. Участие как в написании приложений "с нуля", так и поддержка унаследованного кода. Участие в разработке архитектуры систем. На проектах участвую в ролях тимлида и разработчика.' />
      </div>
    </Fragment>    
  );
};

export default Search; 