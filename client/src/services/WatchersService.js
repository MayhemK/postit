import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { WatcherProfile } from "@/models/Watcher.js"
import { AppState } from "@/AppState.js"

class WatchersService {
  async createWatcher(watcherData) {
    const res = await api.post('api/watchers', watcherData)
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