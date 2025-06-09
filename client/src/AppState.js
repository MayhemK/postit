import { reactive } from 'vue'
import { WatcherAlbum } from './models/Watcher.js'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  /**@type {import('@bcwdev/auth0provider-client').Identity} */
  identity: null,
  /** @type {import('./models/Account.js').Account} user info from the database*/
  account: null,
  /** @type {import('./models/Album.js').Album[]} */
  albums: [],
  /** @type {import('./models/Album.js').Album} */
  activeAlbum: null,
  /** @type {import('./models/Picture.js').Picture[]} */
  pictures: [],
  /** @type {import('./models/Picture.js').Picture} */
  activePicture: null,
  /** @type {import('./models/Watcher.js').WatcherProfile[]} */
  watcherProfiles: [],
  /** @type {import('./models/Watcher.js').WatcherAlbum[]} */
  watcherAlbums: []
})

