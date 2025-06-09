import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { WatcherAlbum, WatcherProfile } from "@/models/Watcher.js"
import { AppState } from "@/AppState.js"

class WatchersService {
  async deleteWatcher(watcherId) {
    const res = await api.delete(`/api/watchers/${watcherId}`)
    logger.log('Deleted Watcher', res.data)
    const watcherAlbums = AppState.watcherAlbums
    const index = watcherAlbums.findIndex(watcher => watcher.id == watcherId)
    watcherAlbums.splice(index, 1)
  }
  async getMyAlbums() {
    const res = await api.get('account/watchers')
    logger.log('got my albums', res.data)
    const watcherAlbums = res.data.map(pojo => new WatcherAlbum(pojo))
    AppState.watcherAlbums = watcherAlbums
  }
  async createWatcher(watcherData) {
    const res = await api.post('api/watchers', watcherData)
    logger.log(res.data)
    const watcher = new WatcherProfile(res.data)
    AppState.watcherProfiles.push(watcher)
    // AppState.activeAlbum.watcherCount++
  }

  async getWatchersByAlbumId(albumId) {
    const res = await api.get(`api/albums/${albumId}/watchers`)
    logger.log(res.data, 'got watchers')
    const watcherProfiles = res.data.map(pojo => new WatcherProfile(pojo))
    AppState.watcherProfiles = watcherProfiles
  }


}

export const watchersService = new WatchersService()