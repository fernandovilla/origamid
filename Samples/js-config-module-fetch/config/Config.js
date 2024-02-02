const getData = async () => {
  const resp = fetch('./config/settings.json').then((response) =>
    response.json(),
  );

  return resp;
};

const getServerAPI = async () => {
  return (await getData()).server;
};

const getServerName = async () => {
  return (await getServerAPI()).name;
};

const getServerURL = async () => {
  return (await getServerAPI()).url;
};

//objeto literal
const configServer = {
  ServerName: async () => {
    return await getServerName();
  },
  URL: async () => {
    return await getServerURL();
  },
};

export default configServer;
export { getServerAPI };
