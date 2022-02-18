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
} from '@material-ui/icons';

const drawerWidth = 240;

const useStyles = makeStyles((theme) => ({
  root: {
    height: '50vh',
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
}));

const Home = () => {
  const classes = useStyles();

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

          <img src="/images/preto.png" alt="logo" className={classes.logo} />
          <div className={classes.grow} />

          <IconButton className={classes.icons} color="inherit">
            <VideoCall />
          </IconButton>

          <IconButton className={classes.icons} color="inherit">
            <Apps />
          </IconButton>

          <IconButton className={classes.icons} color="inherit">
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
        </div>
      </Drawer>
    </div>
  );
};

export default Home;
