import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Catalog } from "./components/Catalog";
import { WhatCanIMake } from './components/WhatCanIMake';
import { Search } from './components/Search';
import { DrinkDetail } from './components/DrinkDetail';

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
        element: <DrinkDetail />
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
