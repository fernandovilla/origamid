const { defineConfig } = require('@vue/cli-service');
module.exports = defineConfig({
  lintOnSave: false,
  //transpileDependencies: true
  configureWebpack: {
    devtool: 'source-map',
  },
});
