import React from 'react';
import { Switch, Route } from 'react-router-dom';
import Resume from 'pages/resume';
import ResumeSent from 'pages/resume/sent';
import Search from 'pages/search';

export default () => {
  return (
    <Switch>
      <Route path="/" component={Resume} exact />
      <Route path="/search/" component={Search} exact />
      <Route path="/resumeSent/" component={ResumeSent} exact />
    </Switch>
  );
};
