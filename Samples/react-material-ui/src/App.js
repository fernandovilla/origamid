import React from 'react';
import { Button, ThemeProvider } from '@material-ui/core';
import { createTheme, makeStyles } from '@material-ui/core/styles';
import Home from './Home';

const useStyles = makeStyles({
  root: { height: '100vh' },
});

const theme = createTheme({
  palette: {
    primary: {
      main: '#f44336',
      // light: will be calculated from palette.primary.main,
      // dark: will be calculated from palette.primary.main,
      // contrastText: will be calculated to contrast with palette.primary.main
    },
    secondary: {
      light: '#c4c4c4',
      main: '#0044ff',
      // dark: will be calculated from palette.secondary.main,
      contrastText: '#ffcc00',
    },
    // Used by `getContrastText()` to maximize the contrast between
    // the background and the text.
    contrastThreshold: 3,
    // Used by the functions below to shift a color's luminance by approximately
    // two indexes within its tonal palette.
    // E.g., shift from Red 500 to Red 300 or Red 700.
    tonalOffset: 0.2,
  },
});

function App() {
  const classes = useStyles();

  return (
    <ThemeProvider theme={theme}>
      <div className={classes.root}>
        <Home />
      </div>
    </ThemeProvider>
  );
}

export default App;
