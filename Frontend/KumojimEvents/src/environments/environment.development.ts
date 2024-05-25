import packageInfo from '../../package.json';
export const environment = {
  production: false,
  BASE_URL: 'http://localhost:5120/',
  VERSION: packageInfo.version,
};
