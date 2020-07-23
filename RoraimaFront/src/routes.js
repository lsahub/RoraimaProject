import React from 'react';
import { Switch, Route } from 'react-router-dom';
import Resume from 'pages/resume';
import Search from 'pages/search';

export default () => {
  return (
    <Switch>
      <Route path="/" component={Resume} exact />
      <Route path="/search/" component={Search} exact />
    </Switch>
  );
};
