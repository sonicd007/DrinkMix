import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Catalog } from "./components/Catalog";
import { WhatCanIMake } from './components/WhatCanIMake';
import { Search } from './components/Search';
import CreateRecipe from './components/CreateRecipe';

const AppRoutes = [
    {
        index: true,
        element: <Catalog />
    },
    {
        path: '/wcim',
        element: <WhatCanIMake />
    },
    {
        path: '/search',
        element: <Search />
    },
    {
        path: '/wip',
        element: <CreateRecipe />
    },
    {
        path: '/counter',
        element: <Counter />
    },
    {
        path: '/fetch-data',
        requireAuth: true,
        element: <FetchData />
    },
    ...ApiAuthorzationRoutes
];

export default AppRoutes;
