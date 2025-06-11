import { api } from "./AxiosService.js"
import { WatcherAlbum, WatcherProfile } from "@/models/Watcher.js"
import { AppState } from "@/AppState.js"
import { Pop } from "@/utils/Pop.js"

class WatchersService {
  async deleteWatcher(watcherId) {
    await api.delete(`/api/watchers/${watcherId}`)
    const watcherAlbums = AppState.watcherAlbums
    const index = watcherAlbums.findIndex(watcher => watcher.watcherId == watcherId)
    if (index !== 1) {
      watcherAlbums.splice(index, 1)
      Pop.success('You are no longer following this album!')
    } else {
      Pop.error('could not find watcher in List')
    }
  }
  async getMyAlbums() {
    const res = await api.get('account/watchers')
    const watcherAlbums = res.data.map(pojo => new WatcherAlbum(pojo))
    AppState.watcherAlbums = watcherAlbums
  }
  async createWatcher(watcherData) {
    const res = await api.post('api/watchers', watcherData)
    const watcher = new WatcherProfile(res.data)
    AppState.watcherProfiles.push(watcher)
  }

  async getWatchersByAlbumId(albumId) {
    const res = await api.get(`api/albums/${albumId}/watchers`)
    const watcherProfiles = res.data.map(pojo => new WatcherProfile(pojo))
    AppState.watcherProfiles = watcherProfiles
  }


}

export const watchersService = new WatchersService()