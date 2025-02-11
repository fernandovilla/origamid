/*const { defineConfig } = require('@vue/cli-service');

const path = require('path');

module.exports = defineConfig({
  publicPath: '/',
  outputDir: 'dist',
  configureWebpack: (config) => {
    if (process.env.NODE_ENV === 'production') {
      // mutate config for production...
    } else {
      // mutate for development...
    }
  },
  lintOnSave: false,
});
*/

module.exports = {
  chainWebpack: (config) => {
    config.plugin('define').tap((definitions) => {
      Object.assign(definitions[0],{
        __VUE_OPTIONS_API__: 'true',
        __VUE_PROD_DEVTOOLS__: 'false',
        __VUE_PROD_HYDRATION_MISMATCH_DETAILS__: 'false'
      })
      return definitions
    })
  }
}