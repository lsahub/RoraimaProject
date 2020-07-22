import  {useEffect} from 'react';
export const useFetching = (someFetchActionCreator, params, callback) => {
    useEffect( () => {
      someFetchActionCreator(params).then(()=>{
        callback && callback();
      });
    }, [])
  } 