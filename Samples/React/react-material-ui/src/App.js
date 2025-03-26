import React, { useState } from 'react';
import { Button, darken, ThemeProvider } from '@material-ui/core';
import { createTheme, makeStyles } from '@material-ui/core/styles';
import Home from './Home';

const useStyles = makeStyles({
  root: { height: '100vh' },
});

function App() {
  const [darkMode, setDarkMode] = useState(false);
  const classes = useStyles();

  const customTheme = createTheme({
    palette: {
      type: darkMode ? 'dark' : 'light',
      primary: {
        main: '#f44336',
        // light: will be calculated from palette.primary.main,
        // dark: will be calculated from palette.primary.main,
        // contrastText: will be calculated to contrast with palette.primary.main
      },
      secondary: {
        light: '#c4c4c4',
        main: '#3ea6ff',
        // dark: will be calculated from palette.secondary.main,
        contrastText: '#ffcc00',
      },
      background: {
        default: darkMode ? '#232323' : '#FFF',
        dark: darkMode ? '#181818' : '#F4F6F8',
        paper: darkMode ? '#232323' : '#FFF',
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

  return (
    <ThemeProvider theme={customTheme}>
      <div className={classes.root}>
        <Home darkMode={darkMode} setDarkMode={setDarkMode} />
      </div>
    </ThemeProvider>
  );
}

export default App;
