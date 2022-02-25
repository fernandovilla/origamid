import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import AppBar from '@material-ui/core/AppBar';
import MenuIcon from '@material-ui/icons/Menu';
import {
  Toolbar,
  IconButton,
  Button,
  Box,
  Drawer,
  List,
  Divider,
  ListItem,
  ListItemIcon,
  ListItemText,
  ListSubheader,
  Typography,
  Grid,
  Hidden,
  Switch,
} from '@material-ui/core';
import {
  AccountCircle,
  VideoCall,
  MoreVert,
  Apps,
  Home as HomeIcon,
  Whatshot,
  Subscriptions,
  VideoLibrary,
  History,
  SettingsSystemDaydreamRounded,
} from '@material-ui/icons';
import { useTheme } from '@material-ui/styles';

const drawerWidth = 240;

const useStyles = makeStyles((theme) => ({
  root: {
    height: '50vh',
    backgroundColor: theme.palette.background.dark,
  },
  appBar: {
    boxShadow: 'none',
    zIndex: theme.zIndex.drawer + 1,
  },
  grow: {
    flexGrow: 1,
  },
  menuIcon: {
    paddingRight: theme.spacing(5),
    paddingLeft: theme.spacing(2),
  },
  icons: {
    paddingRight: theme.spacing(2),
  },
  logo: {
    height: '25px',
  },
  drawer: {
    width: drawerWidth,
    flexShrink: 0,
  },
  drawerPaper: {
    width: drawerWidth,
    borderRight: 'none',
  },
  drawerContainer: {},
  listItem: {
    paddingTop: 4,
    paddingBottom: 4,
  },
  listItemText: {
    fontSize: 14,
  },
  subheader: {
    textTransform: 'uppercase',
  },
}));

const Home = ({ darkMode, setDarkMode }) => {
  const classes = useStyles();
  const theme = useTheme();

  const menuItens = [
    [
      { key: 'inicio', display: 'Início', icon: <HomeIcon /> },
      { key: 'em-alta', display: 'Em alta', icon: <Whatshot /> },
      { key: 'inscricoes', display: 'Inscrições', icon: <Subscriptions /> },
    ],
    [
      { key: 'biblioteca', display: 'Biblioteca', icon: <VideoLibrary /> },
      { key: 'history', display: 'Histórico', icon: <History /> },
    ],
  ];

  const menuItens2 = [
    { key: 'musica', display: 'Música', icon: <HomeIcon /> },
    { key: 'esportes', display: 'Esportes', icon: <HomeIcon /> },
    { key: 'jogos', display: 'Jogos', icon: <HomeIcon /> },
    { key: 'filmes', display: 'Filmes', icon: <HomeIcon /> },
    { key: 'noticias', display: 'Notícias', icon: <HomeIcon /> },
    { key: 'aovivo', display: 'Ao vivo', icon: <HomeIcon /> },
    { key: 'destaque', display: 'Destaque', icon: <HomeIcon /> },
    { key: 'video360', display: 'Video em 360º', icon: <HomeIcon /> },
  ];

  const videos = [
    {
      id: 1,
      title:
        'FEED DO USUARIO | Criando uma Rede Social com React.js e .Net Core #29',
      channel: 'Lucas Nhimi',
      views: '11 mil visualizações',
      date: 'há 1 semana',
      avatar: '/images/avatar.jpeg',
      thumb: '/images/thumb1.png',
    },
    {
      id: 2,
      title:
        'COMO MELHORAR SEU CÓDIGO JAVASCRIPT (ESLINT + PRETTIER + EDITORCONFIG) | Dicas e Truques #02',
      channel: 'Lucas Nhimi',
      views: '957 mil visualizações',
      date: 'há 1 semana',
      avatar: '/images/avatar.jpeg',
      thumb: '/images/thumb2.png',
    },
    {
      id: 3,
      title:
        'CONTEXT API NO EDITOR DE POST | Criando uma Rede Social com React.js e .Net Core #27',
      channel: 'Lucas Nhimi',
      views: '106 mil visualizações',
      date: 'há 1 semana',
      avatar: '/images/avatar.jpeg',
      thumb: '/images/thumb3.png',
    },
    {
      id: 4,
      title:
        'CONTEXT API NO EDITOR DE POST | | Criando uma Rede Social com React.js e .Net Core #26',
      channel: 'Lucas Nhimi',
      views: '106 mil visualizações',
      date: 'há 1 semana',
      avatar: '/images/avatar.jpeg',
      thumb: '/images/thumb4.png',
    },
    {
      id: 5,
      title: 'VIDEO 5',
      channel: 'Lucas Nhimi',
      views: '106 mil visualizações',
      date: 'há 1 semana',
      avatar: '/images/avatar.jpeg',
      thumb: '/images/thumb5.png',
    },
    {
      id: 6,
      title: 'VIDEO 6',
      channel: 'Lucas Nhimi',
      views: '106 mil visualizações',
      date: 'há 1 semana',
      avatar: '/images/avatar.jpeg',
      thumb: '/images/thumb6.png',
    },
    {
      id: 7,
      title: 'VIDEO 7',
      channel: 'Lucas Nhimi',
      views: '106 mil visualizações',
      date: 'há 1 semana',
      avatar: '/images/avatar.jpeg',
      thumb: '/images/thumb6.png',
    },
    {
      id: 8,
      title: 'VIDEO 8',
      channel: 'Lucas Nhimi',
      views: '106 mil visualizações',
      date: 'há 1 semana',
      avatar: '/images/avatar.jpeg',
      thumb: '/images/thumb6.png',
    },
  ];

  return (
    <div className={classes.root}>
      <AppBar color="inherit" className={classes.appBar}>
        <Toolbar>
          <IconButton
            edge="start"
            className={classes.menuIcon}
            color="inherit"
            aria-label="menu"
          >
            <MenuIcon />
          </IconButton>

          <img
            src={
              theme.palette.type === 'dark'
                ? '/images/branco.png'
                : '/images/preto.png'
            }
            alt="logo"
            className={classes.logo}
          />
          <div className={classes.grow} />

          <Switch
            value={darkMode}
            onChange={() => setDarkMode(!darkMode)}
            className={classes.icons}
          />

          <IconButton className={classes.icons}>
            <VideoCall />
          </IconButton>

          <IconButton className={classes.icons}>
            <Apps />
          </IconButton>

          <IconButton className={classes.icons}>
            <MoreVert />
          </IconButton>

          <Button
            variant="outlined"
            color="secondary"
            startIcon={<AccountCircle />}
          >
            Fazer Login
          </Button>
        </Toolbar>
      </AppBar>

      <Box display="flex">
        <Hidden mdDown>
          <Drawer
            className={classes.drawer}
            variant="permanent"
            classes={{ paper: classes.drawerPaper }}
          >
            <Toolbar />
            <div className={classes.drawerContainer}>
              {menuItens.map((menu) =>
                menu.map((item, i) => (
                  <ListItem
                    button
                    key={item.key}
                    classes={{ root: classes.listItem }}
                  >
                    <ListItemIcon>{item.icon}</ListItemIcon>
                    <ListItemText
                      primary={item.display}
                      classes={{ primary: classes.listItemText }}
                    />
                  </ListItem>
                )),
              )}

              <Divider />
              <Box pl={4} pr={3} pt={2} pb={2}>
                <Typography variant="body2">
                  Faça login para curtir vídeos, comentar e se inscrever.
                </Typography>
                <Box mt={2}>
                  <Button
                    variant="outlined"
                    color="secondary"
                    startIcon={<AccountCircle />}
                  >
                    Fazer Login
                  </Button>
                </Box>
              </Box>
              <Divider />
              <List component="nav" aria-labelledby="nested-list-subheader">
                <ListSubheader
                  component="div"
                  id="nested-list-subheader"
                  className={classes.subheader}
                >
                  o melhor do youtube
                </ListSubheader>

                {menuItens2.map((item) => (
                  <ListItem
                    button
                    key={item.key}
                    classes={{ root: classes.listItem }}
                  >
                    <ListItemIcon>{item.icon}</ListItemIcon>
                    <ListItemText
                      primary={item.display}
                      classes={{ primary: classes.listItemText }}
                    />
                  </ListItem>
                ))}
              </List>
            </div>
          </Drawer>
        </Hidden>

        <Box pt={3} pl={10}>
          <Toolbar />
          <Typography
            variant="h5"
            color="textPrimary"
            style={{ fontWeight: 600 }}
          >
            Recomendados
          </Typography>
          <Grid container spacing={3}>
            {videos.map((item, index) => (
              <Grid item lg={3} md={4} sm={6} xs={12}>
                <Box>
                  <img
                    style={{ width: '100%' }}
                    alt={item.title}
                    src={item.thumb}
                  />
                  <Box>
                    <Typography
                      style={{ fontWeight: 600 }}
                      gutterBottom
                      variant="body1"
                      color="textPrimary"
                    >
                      {item.title}
                    </Typography>
                    <Typography
                      display="block"
                      variant="body2"
                      color="textSecondary"
                    >
                      {item.channel}
                    </Typography>
                    <Typography
                      variant="body2"
                      color="textSecondary"
                    >{`${item.views} - ${item.date}`}</Typography>
                  </Box>
                </Box>

                {/* DESENVOLVER O LAYOUT DO GRID... 58:31 */}
              </Grid>
            ))}
          </Grid>
        </Box>
      </Box>
    </div>
  );
};

export default Home;
