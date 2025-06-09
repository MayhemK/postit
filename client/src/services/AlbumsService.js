import { AppState } from "@/AppState.js"
import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Album } from "@/models/Album.js"

class AlbumsService{
  async plusView(albumId) {
    const res = await api.get(`api/albums/${albumId}`)
    AppState.activeAlbum.views++
    AppState.activeAlbum = new Album(res.data)
  }
  async archiveAlbum(albumId) {
    const res = await api.delete(`api/albums/${albumId}`)
    const album = new Album(res.data)
    AppState.activeAlbum = album
  }
  async getAlbumById(albumId) {
    AppState.activeAlbum = null
    const res = await api.get(`api/albums/${albumId}`)
    const album = new Album(res.data)
    AppState.activeAlbum = album
  }
  async createAlbum(albumData) {
    const res = await api.post('api/albums', albumData)
    logger.log('Create Album', res.data)
    const album = new Album(res.data)
    AppState.albums.push(album)
    return album
  }
  async getAlbums() {
    const res = await api.get('api/albums')
    const albums = res.data.map(pojo => new Album(pojo))
    AppState.albums = albums
  }

}
export const albumsService = new AlbumsService()