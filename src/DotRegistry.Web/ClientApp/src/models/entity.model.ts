export abstract class Entity {
  constructor() {
    this.active = false;
    this.createdAt = new Date();
    this.slug = '';
    this.updatedAt = null;
  }

  /**
   * Flag to determine if the current entity was "soft" deleted
   */
  public active: boolean;

  /**
  * When this entity was created
  */
  public createdAt: Date;

  /**
  * The unique slug identifying this entity
  */
  public slug: string;

  /**
  * When this entity was last updated
  */
  public updatedAt: Date | null;
}
