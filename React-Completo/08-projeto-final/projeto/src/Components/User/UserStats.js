import React from 'react';
import useFetch from '../../Hooks/useFetch';
import Head from '../Helper/Head';
import { STATS_GET } from '../../Api';
import Loading from '../Helper/Loading';
import Error from '../Helper/Error';
//import UserStatsGraphs from './UserStatsGraphs';
const UserStatsGraphs = React.lazy(() => import('./UserStatsGraphs'));

const UserStats = () => {
  const { data, error, loading, request } = useFetch();

  React.useEffect(() => {
    async function getData() {
      const { url, options } = STATS_GET();
      const { json } = await request(url, options);
      console.log(json);
    }
    getData();
  }, [request]);

  if (loading) return <Loading />;
  if (error) return <Error error={error} />;

  if (data) {
    return (
      <React.Suspense fallback={<div></div>}>
        <Head title="Estatísticas" />
        <UserStatsGraphs data={data} />
      </React.Suspense>
    );
  }

  return null;
};

export default UserStats;
