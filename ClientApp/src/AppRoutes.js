import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Catalog } from "./components/Catalog";
import { WhatCanIMake } from './components/WhatCanIMake';

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
