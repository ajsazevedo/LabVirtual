import React from 'react';
import { Router, Route } from 'react-router';
import Sidebar from '../components/Sidebar';

import { Home } from '../pages/Home';
import { About } from '../pages/About';
import { Simulators } from '../pages/Simulators';
import { Experiments } from '../pages/Experiments';
import { Bibliography } from '../pages/Bibliography';
import { Remote } from '../pages/Remote';
import { UnderConstruction } from '../pages/UnderConstruction';
import { NoMatch } from '../pages/NoMatch';
import { abouttext } from '../resources/About.txt';


const items = [
  {
    name: 'inicio',
    label: 'Inicio',
    path: '/',
    component: { Home }
  },
  {
    name: 'virtual',
    label: 'Virtual',
    items: [
      { name: 'simulators', label: 'Simuladores', path: '/simulators', component: { Simulators } },
      { name: 'experiments', label: 'Experimentos', path: '/experiments', component: { Experiments } },
      { name: 'bibliography', label: 'Bibliografia', path: '/bibliography', component: { Remote } },
    ],
  },
  {
    name: 'remoto',
    label: 'Remoto',
    items: [
      { name: 'remote', label: 'Acesso remoto', path: '/remote', component: { UnderConstruction } }
    ],
  },
  {
    name: 'settings',
    label: 'Configuracoes',
    items: [
      { name: 'profile', label: 'Perfil', path: '/profile', component: { UnderConstruction } }
    ],
  },
  {
    name: 'about',
    label: 'Sobre',
    path: '/about',
    component: { About }
  }
]


const CreateRoutes = () => (
  <Router>
    <Sidebar items={items} />

    <switch>
      <Route exact path="/" component={Home} />
      <Route path="/about" component={About} />
      <Route path="/simulators" component={Simulators} />
      <Route path="/experiments" component={UnderConstruction} />
      <Route path="/bibliography" component={Bibliography} />
      <Route path="/remote" component={UnderConstruction} />
      <Route path="/underConstruction" component={UnderConstruction} />
      <Route path="/abouttext" component={abouttext} />
      <Route path="/profile" component={UnderConstruction} />
      <Route component={NoMatch} />
    </switch>
  </Router>
);

export default CreateRoutes;