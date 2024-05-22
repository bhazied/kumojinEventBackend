import packageInfo from '../../package.json';
export const environment = {
    production: true,
    BASE_URL: "API_BASE_URL",
    VERSION: packageInfo.version
};
