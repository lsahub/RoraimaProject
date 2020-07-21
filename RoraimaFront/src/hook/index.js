import  {useEffect} from 'react';
export const useFetching = someFetchActionCreator => {
    useEffect( () => {
      someFetchActionCreator();
    }, [])
  } 