import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { WatcherProfile } from "@/models/Watcher.js"
import { AppState } from "@/AppState.js"

class WatchersService {
  async getWatchersByAlbumId(albumId) {
    const res = await api.get(`api/albums/${albumId}/watchers`)
    const watcherProfiles = res.data.map(pojo => new WatcherProfile(pojo))
    AppState.watcherProfiles = watcherProfiles
  }
}

export const watchersService = new WatchersService()